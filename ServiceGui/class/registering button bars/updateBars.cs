updateBars
	| cat newBar bar oldCat |
	self bars do: [:assoc | 
		(bar := assoc value) ifNotNil: [
			oldCat := assoc key.
			cat := oldCat id service.
			cat requestor: oldCat requestor.
			newBar := self new buttonBarFor: cat.
			bar removeAllMorphs.
			newBar submorphsDo: [:m | bar addMorphBack: m]].
		]