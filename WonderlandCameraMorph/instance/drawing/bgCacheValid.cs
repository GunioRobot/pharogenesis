bgCacheValid
	| bg |
	bg _ self valueOfProperty: #backgroundSnapshot ifAbsent:[^false].
	^bg extent = self extent and:[bg depth = Display depth and:[Display isB3DDisplayScreen == bg isExternalForm]]