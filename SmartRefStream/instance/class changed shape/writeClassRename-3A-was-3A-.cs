writeClassRename: newName was: oldName
	"Write a method that tells which modern class to map instances to."
	| oldVer sel code |

	oldVer _ self versionSymbol: (structures at: oldName).
	sel _ oldName asString.
	sel at: 1 put: (sel at: 1) asLowercase.
	sel _ sel, oldVer.	"i.e. #rectangleoc4"

	code _ WriteStream on: (String new: 500).
	code nextPutAll: sel; cr.
	code cr; tab; nextPutAll: '^ ', newName.	"Return new class"

	self class compile: code contents classified: 'conversion'.

