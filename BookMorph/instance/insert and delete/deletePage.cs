deletePage

	| message |
	message _ 
'Are you certain that you
want to delete this page and
everything that is on it? '.
	(self confirm: message) ifTrue: 
			[self deletePageBasic].
	