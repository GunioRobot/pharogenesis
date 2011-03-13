fetchDocSel: aSelector class: className
	"Look on servers to see if there is documentation pane for the selected message. Take into account the current update number.  If not, ask the user if she wants to create a blank one."

	| key response docPane ext |
	key _ aSelector size = 0 
		ifFalse: [className, ' ', aSelector]
		ifTrue: [className].
	(self openDocAt: key) ifNil: [
		response _ (PopUpMenu labels: 'Create new page\Cancel' withCRs)
				startUpWithCaption: 'No documentation exists for this method.\
Would you like to write some?' withCRs.
		response = 1 ifTrue: [
			docPane _ PasteUpMorph new.
			docPane color: Color white; borderWidth: 2; borderColor: Color green.
			docPane setProperty: #classAndMethod toValue: key.
			docPane setProperty: #initialExtent toValue: (ext _ 200@200).
			docPane topLeft: (RealEstateAgent initialFrameFor: docPane world: Smalltalk currentWorld) origin.
			docPane extent: ext.
			docPane addMorph: (TextMorph new topLeft: docPane topLeft + (10@10);
					extent: docPane width - 15 @ 30).
			Smalltalk currentWorld addMorph: docPane]].

	"If found, openDocAt: put it on the screen"