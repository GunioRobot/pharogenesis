chooseTrigger
	"NB; the keyStroke branch commented out temporarily until keystrokes can actually be passed along to the user's scripting code"
	| aMenu reply standardStati aScriptInstantiation m |
	standardStati _ #(normal paused ticking mouseDown mouseStillDown mouseUp mouseEnter mouseLeave mouseEnterDragging mouseLeaveDragging opening closing "keyStroke").
	aScriptInstantiation _ self scriptInstantiation.
	aMenu _ SelectionMenu labelList:  #(
		'normal'		" -- run when called"		
		'paused' 		"ready to run all the time"
		'ticking'		"run all the time"
		'mouseDown'	"run when mouse goes down on me"
		'mouseStillDown'	"while mouse still down"
		'mouseUp'		"when mouse comes back up"
		'mouseEnter'	"when mouse enters my bounds, button up"
		'mouseLeave'	"when mouse exits my bounds, button up"
		'mouseEnterDragging'	"when mouse enters my bounds, button down"
		'mouseLeaveDragging'	"when mouse exits my bounds, button down"
		'opening'	"when I am being opened"
		'closing'	"when I am being closed"
	"	'keyStroke'	run when user hits a key"
		'what do these mean?'
		)
		lines: #(1 3 6 10 12)
		selections: (standardStati, #(explainStatusAlternatives)).

	reply _ aMenu startUpWithCaption: 'When should this script run?'.
	(reply == #keyStroke) ifTrue: [^ self inform: 'user-scripted fielding
of keystrokes is not
yet available.'].

	reply == #explainStatusAlternatives ifTrue: [^ self explainStatusAlternatives].
	reply ifNotNil: 
		[aScriptInstantiation status: reply.  "Gets event handlers fixed up"
		reply == #ticking ifTrue: [playerScripted costume arrangeToStartStepping].
		reply == #paused ifTrue: [
			m _ playerScripted costume.
			(m isKindOf: SpeakerMorph) ifTrue: [m stopSound]].
		self updateStatus]