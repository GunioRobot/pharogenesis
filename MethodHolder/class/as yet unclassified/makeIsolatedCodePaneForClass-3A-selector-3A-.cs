makeIsolatedCodePaneForClass: aClass selector: aSelector
	| aCodePane aMethodHolder |
	"Create and schedule a message list browser populated only by the currently selected message"

	Smalltalk isMorphic ifFalse:
		[^ self inform: 
'sorry, this feature is currently
only available in morphic projects.'].
	aMethodHolder _ self new.
	aMethodHolder methodClass: aClass methodSelector: aSelector.

	aCodePane _ MethodMorph on: aMethodHolder text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	aMethodHolder addDependent: aCodePane.
	aCodePane borderWidth: 2; color: Color white.
	aCodePane scrollBarOnLeft: false.
	aCodePane width: 300.
	"aCodePane changeStyleTo: 'ComicBold'.
	aCodePane changeFontForAllTo: 'ComicBold16'."
	self currentHand attachMorph: aCodePane