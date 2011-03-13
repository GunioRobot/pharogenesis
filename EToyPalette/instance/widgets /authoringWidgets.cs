authoringWidgets
	"Return a list of authoring widgets"

	| widgets aHolder |

	aHolder _ self world standardHolder.
	widgets _ OrderedCollection new.
	#(RectangleMorph EllipseMorph StarMorph  CurveMorph PolygonMorph) do:
		[:sym | widgets add: ((Smalltalk at: sym) authoringPrototypeIn: aHolder)].

	^ widgets
