rename: aString 
	"The new name of the receiver is the argument, aString."

	| oldName newName |
	(newName _ aString asSymbol) = (oldName _ self name)
		ifTrue: [^ self].
	(self environment includesKey: newName)
		ifTrue: [^ self error: newName , ' already exists'].
	(Undeclared includesKey: newName)
		ifTrue: [self inform: 'There are references to, ' , aString printString , '
from Undeclared. Check them after this change.'].
	name _ newName.
	self environment renameClass: self from: oldName