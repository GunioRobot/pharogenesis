offsetX: aNumber

	| transform |

	transform _ self myTransformMorph.
	transform offset: aNumber @ transform offset y
