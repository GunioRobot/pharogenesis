nextSlotFor: shortDescription
	| bar slots label |
	lock critical: [
		slots _ bars size.
		activeSlots = slots ifTrue: [^0].
		activeSlots _ activeSlots + 1.
		1 to: slots do: [:index |
			bar _ (bars at: index).
			bar ifNil: [
				bar _ bars at: index put: (SystemProgressBarMorph new extent: BarWidth@BarHeight).
				label _ labels at: index put: (StringMorph contents: shortDescription font: font).
				self
					addMorphBack: label;
					addMorphBack: bar.
				^index].
			bar owner ifNil: [
				bar _ bars at: index.
				label _ labels at: index.
				self
					addMorphBack: (label contents: shortDescription);
					addMorphBack: (bar barSize: 0).
				^index]]]
		