discardWonderland
	"Smalltalk discardWonderland"
	"Discard 3D Support."
	self
		at: #Wonderland
		ifPresent: [:cls | cls removeActorPrototypesFromSystem].
	self
		removeKey: #WonderlandConstants
		ifAbsent: [].
	self
		removeKey: #AliceConstants
		ifAbsent: [].
	SystemOrganization removeCategoriesMatching: 'Balloon3D-Wonderland*'.
	SystemOrganization removeCategoriesMatching: 'Balloon3D-Alice*'.
	SystemOrganization removeCategoriesMatching: 'Balloon3D-Pooh*'.
	SystemOrganization removeCategoriesMatching: 'Balloon3D-UserObjects'.
	self
		at: #VRMLWonderlandBuilder
		ifPresent: [:cls | cls removeFromSystem]