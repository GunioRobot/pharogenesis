deleteCurrentPage

	| outerWrapper |

	loadedProject ifNil: [^self].
	outerWrapper _ loadedProject world ownerThatIsA: EmbeddedWorldBorderMorph.
	outerWrapper ifNil: [^self].
	outerWrapper delete.
	loadedProject _ nil.

