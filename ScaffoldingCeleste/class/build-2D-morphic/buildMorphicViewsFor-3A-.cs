buildMorphicViewsFor: model 
	"Answer a dictionary of window panes for the Celeste user interface."
	|  views v |
	views _ Dictionary new.
	views at: #categoryList put: (self buildMorphicCategoryListFor: model).
	views at: #tocEntryList put: (self buildMorphicTocEntryListFor: model).

	v _ self buildMorphicMessageTextPaneFor: model.
	model messageTextView: v.
	views at: #messageText put: v.


	views at: #status put: (self buildMorphicStatusPaneFor: model).
	views at: #outBoxStatus put: (self buildMorphicOutBoxStatusPaneFor: model).
	views at: #categoryList put: (self buildMorphicCategoryListFor: model).
	^ views
