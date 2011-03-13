buildTopMorphicWindowTitled: title model: model 
	| topWindow views buttons |
	topWindow _ (SystemWindow labelled: title)
				model: model.
	buttons _ self buildButtonsFor: model.
	views _ self buildMorphicViewsFor: model.
	self addMorphicViews: views andButtons: buttons to: topWindow .
	buttons
		do: [:b | b onColor: Color lightGray offColor: Color white].
	^ topWindow