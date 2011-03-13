browseImplementorsOf: aSymbol name: titleString autoSelect: autoSelectString
	"Open a implementors browser"
	self default ifNil:[^self inform: 'Cannot open ImplementorsBrowser'].
	^self default browseImplementorsOf: aSymbol name: titleString autoSelect: autoSelectString