abbreviatedWordingFor: aButtonSelector
	"Answer the abbreviated form of wording, from a static table which you're welcome to edit.  Answer nil if there is no entry -- in which case the long firm will be used on the corresponding browser button."

	#(
	(browseMethodFull				'browse')
	(browseSendersOfMessages	   	'senders')
	(browseMessages				'impl')
	(browseVersions					'vers')
	(methodHierarchy				'inher')
	(classHierarchy					'hier')
	(browseInstVarRefs				'iVar')
	(browseClassVarRefs				'cVar')
	(offerMenu						'menu')) do:

		[:pair | pair first == aButtonSelector ifTrue: [^ pair second]].
	^ nil