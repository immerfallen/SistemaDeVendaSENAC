Param(
  [Parameter(Mandatory=$true)][string]$version
)

Get-ChildItem -Path .\*\*  -Filter *.csproj | 
Foreach-Object {
    $content = Get-Content $_.FullName

	$content | 
	Foreach-Object {$_ -replace "<Version>(.+)<\/Version>", ("<Version>"+$version+"</Version>")} | 
	Set-Content $_.FullName
}

Get-ChildItem -Path .\*\*  -Filter package.json | 
Foreach-Object {
    $content = Get-Content $_.FullName

	$content | 
	Foreach-Object {$_ -replace '"version":\s*".+",', ('"version": "'+$version+'",')} | 
	Set-Content $_.FullName
}