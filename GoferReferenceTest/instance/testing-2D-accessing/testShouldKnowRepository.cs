testShouldKnowRepository
	| package |
	package := GoferPackageReference name: 'Gofer' repository: self goferRepository.
	self assert: package repository locationWithTrailingSlash = 'http://source.lukas-renggli.ch/flair/'.
	
	package := GoferConstraintReference name: 'Gofer' repository: self goferRepository.
	self assert: package repository locationWithTrailingSlash = 'http://source.lukas-renggli.ch/flair/'.
	
	package := GoferVersionReference name: 'Gofer-lr.34' repository: self goferRepository.
	self assert: package repository locationWithTrailingSlash = 'http://source.lukas-renggli.ch/flair/'