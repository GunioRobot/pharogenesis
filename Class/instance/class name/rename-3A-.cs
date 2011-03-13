rename: aString 
	"The new name of the receiver is the argument, aString."

	| newName |
	newName _ aString asSymbol.
	(Smalltalk includesKey: newName)
		ifTrue: [^self error: newName , ' already exists'].
	(Undeclared includesKey: newName)
		ifTrue: [^ SelectionMenu notify: 'There are references to, ' , aString printString , '
from Undeclared. Check them after this change.'].
	Smalltalk renameClass: self as: newName.
	name _ newName.
	self comment: self comment.
