minorShrink
	"This method throws out lots of the system that is not needed, although not quite as much as majorShrink. In particular, it retains Morphic, Sound, graphics file readers, and the networking classes."
	"Smalltalk minorShrink"

	(Smalltalk includesKey: #CCodeGenerator) ifTrue:
		[(Smalltalk at: #CCodeGenerator) removeCompilerMethods].
	SystemOrganization removeCategoriesMatching: 'Squeak-*'.
	SystemOrganization removeSystemCategory: 'Graphics-Symbols'.
	SystemOrganization removeSystemCategory: 'Interface-Pluggable'.

	Form removeSelector: #edit.
	Form removeSelector: #bitEdit.
	Form removeSelector: #bitEditAt:scale:.
	StrikeFont removeSelector: #edit:.
	Dictionary removeSelector: #inspectFormsWithLabel:.
	InspectorView class removeSelector: #buildFormView:.
	InspectorView class removeSelector: #formDictionaryInspector:.
	Object removeSelector: #evaluate:wheneverChangeIn:.
	SystemDictionary removeSelector: #viewGIFImports.
	ScreenController removeSelector: #viewGIFImports.

	FormEditor removeSelector: #curve.
	CurveFitter removeFromSystem.
	LinearFit removeFromSystem.
	Spline removeFromSystem.

	FormView compile: 'defaultControllerClass 
	^  NoController' classified: 'controller access'.
	Form removeSelector: #edit.
	FormEditor removeFromSystem.
	FormEditorView removeFromSystem.
	FormMenuView removeFromSystem.
	FormMenuController removeFromSystem.
	FormButtonCache removeFromSystem.
	BitEditor removeFromSystem.
	FormHolderView removeFromSystem.
	FormInspectView removeFromSystem.

	ParagraphEditor removeSelector: #recognizeCharacters.
	ParagraphEditor removeSelector: #recognizer:.
	ParagraphEditor removeSelector: #recognizeCharactersWhileMouseIn:.
	CharRecog removeFromSystem.

	Array2D removeFromSystem.
	FFT removeFromSystem.

	HierarchicalMenu removeFromSystem.
	ObjectViewer removeFromSystem.
	ObjectTracer removeFromSystem.
	StandardFileStream removeSelector: #asHtml.
	HtmlFileStream removeFromSystem.
	ConciseInspector removeFromSystem.
	Smalltalk removeEmptyMessageCategories.
	Smalltalk cleanOutUndeclared.
	Smalltalk reclaimDependents.

	"remove shrink methods"
	SystemDictionary removeSelector: #majorShrink.
	SystemDictionary removeSelector: #minorShrink.

	Smalltalk noChanges.
	ChangeSorter classPool at: #AllChangeSets put: (OrderedCollection with: Smalltalk changes).

	Symbol rehash.
