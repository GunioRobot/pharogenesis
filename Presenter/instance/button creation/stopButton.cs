stopButton
	| aDict aPosition anExtent |
	stopButton ifNil:
		[aDict _ ScriptingSystem formDictionary.
		stopButton _ ThreePhaseButtonMorph new.
		stopButton image:  (aDict at: 'StopPic');
			offImage: (aDict at: 'StopPic'); pressedImage:  (aDict at: 'StopPicOn').
		stopButton actionSelector: #stopUp:with:; 
			arguments: (Array with: nil with: stopButton);
			actWhen: #buttonUp; target: self;
			setNameTo: 'Stop Button'; 
			setProperty: #scriptingControl toValue: true;
			setBalloonText:
'Press Stop to stop all
running scripts.'].

	stopButton isInWorld ifFalse:
		[anExtent _ stopButton extent.
		aPosition _ 128 @ (associatedMorph height - 30).
		aPosition _ associatedMorph positionNear: aPosition forExtent:  anExtent adjustmentSuggestion: (0 @ (anExtent y negated)).
		associatedMorph addMorph: (stopButton beRepelling position: aPosition)].
	
	^ stopButton