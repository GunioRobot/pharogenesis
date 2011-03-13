offsetY: aNumber

	| transform |

	transform _ self myTransformMorph.
	transform offset: transform offset x @ aNumber
