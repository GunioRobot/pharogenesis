trimScaffoldingBookBeforeSaving
	| toy bb |

	"Currently disused"
	true ifTrue: [^ self].

	"Look for Actors in BookMorph, and ask author if they should really carry scripts."
"	model class instVarNames size > 0 ifTrue: [^ self]."	"User is saving.  Don't bother her"
	toy _ scaffoldingBook pageNamed: 'Toy'.

	SketchMorph allInstancesDo: [:aa | 
		aa hasScript ifTrue:
		[(bb _ aa owner "page") ifNotNil: [(bb _ bb owner "book") == toy 
			ifTrue: [self mayActorDropScript: aa]
			ifFalse: [bb ifNotNil: [(bb _ bb owner "book?") == toy
							ifTrue: [self mayActorDropScript: aa]]]]]]