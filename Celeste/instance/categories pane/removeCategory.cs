removeCategory
	"Remove the existing category with the user-specified name."

	| msgList |
	currentCategory ifNil: [ ^self ].

	msgList _ mailDB messagesIn: currentCategory.
	(mailDB messagesIn: '.trash.') do: [: id |
		msgList remove: id ifAbsent: []].
	msgList isEmpty ifFalse: [
		(self confirm:
'This category is not empty. Are
you sure you wish to remove it?') ifFalse: [^self]].
	mailDB removeCategory: currentCategory.

	self changed: #categoryList.
	self setCategory: nil.
