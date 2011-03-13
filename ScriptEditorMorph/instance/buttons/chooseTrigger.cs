chooseTrigger
	"NB; the keyStroke branch commented out temporarily until keystrokes can actually be passed along to the user's scripting code"
	| aMenu reply standardStati aScriptInstantiation |
	standardStati _ #(normal paused ticking mouseDown mouseStillDown mouseUp mouseEnter mouseLeave "keyStroke").
	aScriptInstantiation _ self scriptInstantiation.
	aMenu _ SelectionMenu labelList:  #(
		'normal -- run when called'
		'paused -- ready to run all the time'
		'ticking -- run all the time'
		'mouseDown -- run when mouse goes down on me'
		'mouseStillDown -- while mouse still down'
		'mouseUp -- when mouse comes back up'
		'mouseEnter -- when mouse enters me with button up'
		'mouseLeave -- when mouse exits me with button up'
	"	'keyStroke -- run when user hits a key' "
		)
		lines: #(1 3 "8")
		selections: standardStati.

	reply _ aMenu startUpWithCaption: 'When should this script run?'.
	(reply == #keyStroke) ifTrue: [^ self inform: 'user-scripted fielding
of keystrokes is not
yet available.'].

	reply ifNotNil: 
		[aScriptInstantiation status: reply.  "Gets event handlers fixed up"
		reply == #ticking ifTrue: [playerScripted costume startStepping].
		self updateStatus]