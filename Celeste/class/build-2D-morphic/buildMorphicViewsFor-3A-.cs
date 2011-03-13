buildMorphicViewsFor: model 
	"Answer a dictionary of window panes for the Celeste user interface."
	| listFont views v |
	listFont _ StrikeFont allSubInstances
				detect: [:f | (f name beginsWith: 'CourierFixed')
						and: [f height = 11]]
				ifNone: [TextStyle defaultFont].
	views _ Dictionary new.
	v _ self buildMorphicCategoryListFor: model.
	views at: #categoryList put: v.
	v _ self buildMorphicTocEntryListFor: model.
	v font: listFont.
	views at: #tocEntryList put: v.
	v _ self buildMorphicMessageTextPaneFor: model.
	v borderWidth: 1.
	model messageTextView: v.
	views at: #messageText put: v.
	v _ self buildMorphicStatusPaneFor: model.
	v borderWidth: 1.
	views at: #status put: v.
	^ views