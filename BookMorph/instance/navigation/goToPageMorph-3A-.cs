goToPageMorph: aMorph

	self goToPage: (pages identityIndexOf: aMorph ifAbsent: [^ self "abort"]).
