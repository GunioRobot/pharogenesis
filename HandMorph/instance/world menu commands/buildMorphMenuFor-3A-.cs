buildMorphMenuFor: argMorph
	"Build the morph menu. This menu has two sections. The first section contains commands that are handled by the hand; the second contains commands handled by the argument morph."

	| menu |
	argument _ argMorph.
	menu _ MenuMorph new defaultTarget: self.
	menu addStayUpItem.

	menu add: 'grab' action: #grabMorph.
	menu add: 'delete' action: #dismissMorph.
	menu addLine.
	menu add: 'copy to paste buffer' action: #copyToPasteBuffer.
	menu add: 'copy Postscript' target: argMorph action: #clipPostscript.
	menu add: 'print PS to file...' target: argMorph action: #printPSToFile.
	menu addLine.
	menu add: 'go behind' action: #goBehind.
	menu add: 'add halo' action: #addHalo.
	menu add: 'duplicate' action: #maybeDuplicateMorph.

	self potentialEmbeddingTargets size > 1 ifTrue:
		[menu add: 'embed...' action: #placeArgumentIn].

	menu add: 'resize' action: #resizeMorph.
	"Give the argument control over what should be done about fill styles"
	argMorph addFillStyleMenuItems: menu hand: self.

	(argMorph morphsAt: targetOffset) size > 1 ifTrue:
		[menu add: 'submorphs...'
			target: self
			selector: #selectSubmorphToOperateOn:sending:event:
			argumentList: (Array with: argMorph with: #operateOnSubmorph:event:)].
	menu addLine.
	Smalltalk isMorphic
		ifTrue: [menu add: 'inspect' action: #inspectMorph]
		ifFalse: [menu add: 'inspect (in MVC)' action: #inspectMorph.
				menu add: 'inspect' action: #inspectMorphInMorphic].
	menu add: 'explore' target: argument action: #explore.
	menu add: 'browse hierarchy' target: argument action: #browseHierarchy.
	menu add: 'make own subclass' action: #subclassMorph.
	menu addLine.
	menu add: 'set variable name...' action: #nameMorph.
	(argMorph isKindOf: MorphicModel) ifTrue:
		[menu add: 'save morph as prototype' action: #saveAsPrototype.
		(argMorph ~~ self world modelOrNil) ifTrue:
			 [menu add: 'become this world''s model' action: #beThisWorldsModel]].
	menu add: 'save morph in file' action: #saveOnFile.
	(argMorph hasProperty: #resourceFilePath)
		ifTrue: [((argMorph valueOfProperty: #resourceFilePath) endsWith: '.morph')
				ifTrue: [menu add: 'save as resource' target: argMorph action: #saveAsResource].
				menu add: 'update from resource' target: argMorph action: #updateFromResource]
		ifFalse: [menu add: 'attach to resource' target: argMorph action: #attachToResource].
	menu add: 'show actions' action: #showActions.
	menu addLine.
	menu defaultTarget: argMorph.
	argMorph addCustomMenuItems: menu hand: self.
	^ menu
