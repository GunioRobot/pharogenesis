discard3D
	"Discard 3D Support.
Updated for 2.8 TPR"

	Smalltalk removeKey: #WonderlandConstants ifAbsent: [].
	Smalltalk removeKey: #AliceConstants ifAbsent: [].
	Smalltalk removeKey: #B3DEngineConstants ifAbsent: [].
	SystemOrganization removeCategoriesMatching: 'Morphic-Balloon3D'.
	SystemOrganization removeCategoriesMatching: 'Balloon3D-*'.
	SystemOrganization removeCategoriesMatching: 'Pooh-*'

