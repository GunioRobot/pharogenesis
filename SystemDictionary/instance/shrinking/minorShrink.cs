minorShrink
	"This method throws out lots of the system that is not needed, although not quite as much as majorShrink. In particular, it retains Morphic, Sound, graphics file readers, and the networking classes."
	"Smalltalk minorShrink"

	(Smalltalk confirm:
'About to delete some infrequently used classes and
methods from your image; do you wish to continue?')
		ifFalse: [^ self].

	"virtual machine construction and Smalltalk-to-C translator:"
	Smalltalk discardVMConstructionClasses.

	"old Form editor:"
	SystemOrganization removeSystemCategory: 'Graphics-Symbols'.
	Form removeSelector: #edit.
	(Smalltalk includesKey: #FormView) ifTrue: [
		(Smalltalk at: #FormView)
			compile: 'defaultControllerClass  ^ NoController'
			classified: 'controller access'].
	Smalltalk removeClassNamed: #FormEditorView.
	Smalltalk removeClassNamed: #FormEditor.
	SystemOrganization removeSystemCategory: 'Graphics-Paths'.

	"bit editor (remove Form editor first):"
	Form removeSelector: #bitEdit.
	Form removeSelector: #bitEditAt:scale:.
	StrikeFont removeSelector: #edit:.
	Smalltalk removeClassNamed: #FormButtonCache.
	Smalltalk removeClassNamed: #FormMenuController.
	Smalltalk removeClassNamed: #FormMenuView.
	Smalltalk removeClassNamed: #BitEditor.

	"inspector for Dictionaries of Forms"
	Dictionary removeSelector: #inspectFormsWithLabel:.
	SystemDictionary removeSelector: #viewGIFImports.
	ScreenController removeSelector: #viewGIFImports.
	Smalltalk removeClassNamed: #FormHolderView.
	Smalltalk removeClassNamed: #FormInspectView.

	"curve fitting:"
	(Smalltalk includesKey: #FormEditor)
		ifTrue: [(Smalltalk at: #FormEditor) removeSelector: #curve].
	Smalltalk removeClassNamed: #CurveFitter.
	Smalltalk removeClassNamed: #LinearFit.
	Smalltalk removeClassNamed: #Spline.

	"experimental hand-drawn character recoginizer:"
	ParagraphEditor removeSelector: #recognizeCharacters.
	ParagraphEditor removeSelector: #recognizer:.
	ParagraphEditor removeSelector: #recognizeCharactersWhileMouseIn:.
	Smalltalk removeClassNamed: #CharRecog.

	"experimental updating object viewer:"
	Object removeSelector: #evaluate:wheneverChangeIn:.
	Smalltalk removeClassNamed: #ObjectViewer.
	Smalltalk removeClassNamed: #ObjectTracer.

	"HTML formatted fileout support:"
	StandardFileStream removeSelector: #asHtml.
	Smalltalk removeClassNamed: #HtmlFileStream.

	"miscellaneous classes:"
	Smalltalk removeClassNamed: #Array2D.
	Smalltalk removeClassNamed: #DriveACar.
	Smalltalk removeClassNamed: #EventRecorder.
	Smalltalk removeClassNamed: #FFT.
	Smalltalk removeClassNamed: #FindTheLight.
	Smalltalk removeClassNamed: #PluggableTest.
	Smalltalk removeClassNamed: #SharedQueue.
	Smalltalk removeClassNamed: #SystemMonitor.

	(Smalltalk confirm: 'Remove all sounds from the SampledSound library?')
		ifTrue: [(Smalltalk at: #SampledSound) initialize].

	"post-removal cleanups"
	Smalltalk removeEmptyMessageCategories.
	Smalltalk cleanOutUndeclared.
	Smalltalk reclaimDependents.
	Symbol rehash.
