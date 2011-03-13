optionalButtonPairs
	"Answer a tuple (formerly pairs) defining buttons, in the format:
			button label
			selector to send
			help message"

	^ #(
	('senders' 			browseSendersOfMessages	'browse senders of...')
	('implementors'		browseMessages				'browse implementors of...')
	('versions'			browseVersions				'browse versions')
	('inheritance'		methodHierarchy			'browse method inheritance
green: sends to super
tan: has override(s)
mauve: both of the above')
	('hierarchy'		classHierarchy				'browse class hierarchy')
	('inst vars'			browseInstVarRefs			'inst var refs...')
	('class vars'			browseClassVarRefs			'class var refs...'))