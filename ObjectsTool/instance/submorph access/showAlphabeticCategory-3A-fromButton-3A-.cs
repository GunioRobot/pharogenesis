showAlphabeticCategory: aString fromButton: aButton 
	"Blast items beginning with a given letter into my lower pane"
	| eligibleClasses quads uc |
	self partsBin removeAllMorphs.
	uc := aString asUppercase asCharacter.
	Cursor wait
		showWhile: [eligibleClasses := Morph withAllSubclasses.
			quads := OrderedCollection new.
			eligibleClasses
				do: [:aClass | aClass theNonMetaClass
						addPartsDescriptorQuadsTo: quads
						if: [:info | info formalName translated asUppercase first = uc]].
			self installQuads: quads fromButton: aButton]