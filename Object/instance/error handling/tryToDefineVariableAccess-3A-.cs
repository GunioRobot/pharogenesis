tryToDefineVariableAccess: aMessage
	"See if the message just wants to get at an instance variable of this class.  Ask the user if its OK.  If so, define the message to read or write that instance or class variable and retry."
	| ask newMessage sel |
	aMessage arguments size > 1 ifTrue: [^ false].
	sel _ aMessage selector asString.	"works for 0 args"
	aMessage arguments size = 1 ifTrue: [
		sel last = $: ifFalse: [^ false].
		sel _ sel copyWithout: $:].
	(self class instVarNames includes: sel) ifFalse: [
		(self class classVarNames includes: sel asSymbol) ifFalse: [
			^ false]].
	ask _ self confirm: 'A ', thisContext sender sender receiver 
		class printString, ' wants to ', 
		(aMessage arguments size = 1 ifTrue: ['write into'] ifFalse: ['read from']), '
', sel ,' in class ', self class printString, '.
Define a this access message?'.
	ask ifTrue: [
		aMessage arguments size = 1 
			ifTrue: [newMessage _ aMessage selector, ' anObject
	', sel, ' _ anObject']
			ifFalse: [newMessage _ aMessage selector, '
	^', aMessage selector].
		self class compile: newMessage classified: 'accessing' notifying: nil].
	^ ask