buildMorphMenuFor: argMorph
	"Build the morph menu. This menu has two sections. The first section contains commands that are handled by the hand; the second contains commands handled by the argument morph."

	| menu |
	argument _ argMorph.
	menu _ MenuMorph new defaultTarget: self.
	menu addStayUpItem.

	menu add: 'grab' action: #grabMorph.
	menu add: 'delete' action: #dismissMorph.
	menu add: 'go behind' action: #goBehind.
	menu add: 'add halo' action: #addHalo.
	menu add: 'duplicate' action: #duplicateMorph.
	((self world rootMorphsAt: targetOffset) size > 1)
		ifTrue: [menu add: 'embed' action: #embedMorph].

	menu add: 'resize' action: #resizeMorph.
	(argMorph isKindOf: SketchMorph)  ifFalse: [
		menu add: 'fill color' action: #changeColor].
	(argMorph morphsAt: targetOffset) size > 1 ifTrue: [
		menu add: 'submorphs...'
			target: self
			selector: #selectSubmorphToOperateOn:sending:event:
			argumentList: (Array with: argMorph with: #operateOnSubmorph:event:)].
	menu addLine.
	menu add: 'inspect' action: #inspectMorph.
	menu add: 'browse' action: #browseMorphClass.
	menu add: 'make own subclass' action: #subclassMorph.
	menu addLine.
	menu add: 'name me' action: #nameMorph.
	(argMorph isKindOf: MorphicModel) ifTrue: [
		menu add: 'save morph as prototype' action: #saveAsPrototype.
		(argMorph ~~ self world modelOrNil) ifTrue: [
			 menu add: 'become this world''s model' action: #beThisWorldsModel]].
	menu add: 'save morph in file' action: #saveMorphInFile.
	menu add: 'show actions' action: #showActions.
	menu addLine.
	menu defaultTarget: argMorph.
	argMorph addCustomMenuItems: menu hand: self.
	^ menu
