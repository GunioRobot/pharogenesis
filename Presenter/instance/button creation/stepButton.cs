stepButton
	| aDict aPosition |
	stepButton ifNil:
		[aDict _ ScriptingSystem formDictionary.
		stepButton _ ThreePhaseButtonMorph new.
		stepButton image:  (aDict at: 'StepPicOn');
			offImage: (aDict at: 'StepPic'); pressedImage:  (aDict at: 'StepPicOn');
			actionSelector: #stepStillDown:with:; 
			arguments: (Array with: nil with: stepButton);
			actWhen: #buttonUp; target: self;
			setNameTo: 'Step Button'; 
			setProperty: #scriptingControl toValue: true;
			on: #mouseDown send: #stepDown:with: to: self;
			on: #mouseStillDown send: #stepStillDown:with: to: self;
			on: #mouseUp send: #stepUp:with: to: self;
			setBalloonText:
'Press Step to run every paused
script exactly once.  Keep
the mouse button down over "Step"
and everything will keep running
until you release it'].
	stepButton isInWorld ifFalse:
		[aPosition _ associatedMorph
			positionNear:
				(self stopButton topRight + (1@0))
			 forExtent:
				stepButton extent
			adjustmentSuggestion:
				(0 @ (stepButton height negated)).
		associatedMorph addMorph: (stepButton beRepelling position: aPosition)].
	^ stepButton