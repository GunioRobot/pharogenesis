buildButtonsFor: model 
	"Answer a collection of handy buttons for the Celeste user interface."
	^ self buttonSpecs collect: [ :spec |
		self buildButtonFromSpec: spec forModel: model ].
