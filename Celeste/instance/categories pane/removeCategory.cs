removeCategory
	"Remove the existing category with the user-specified name."

	| msgList |
	mailDB ifNil: [ ^self ].
	self category ifNil: [ ^self ].

	msgList _ mailDB messagesIn: self category.
	(mailDB messagesIn: '.trash.') do: [: id |
		msgList remove: id ifAbsent: []].
	msgList isEmpty ifFalse: [
		(self confirm:
'This category is not empty. Are
you sure you wish to remove it?') ifFalse: [^self]].
	mailDB removeCategory: self category.

	self updateTOC.
	self changed: #categoryList.
