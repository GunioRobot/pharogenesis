destroyScript
	| aMenu reply |
	true ifTrue: [^ playerScripted removeScript: scriptName].

	self flag: #deferred.  "revisit"
	(playerScripted okayToDestroyScriptNamed: scriptName)
		ifFalse:
			[^ self inform: 'Sorry, this script is being called
from another script.'].

	(self isAnonymous not and: [submorphs size > 1]) ifTrue:
		[aMenu _ SelectionMenu selections: #('destroy it' 'oops, no, don''t destroy').
		reply _ aMenu startUpWithCaption: 'Do you really want to
destroy this script?'.
		(reply = 'destroy it') ifFalse: [^ self]].

	self actuallyDestroyScript