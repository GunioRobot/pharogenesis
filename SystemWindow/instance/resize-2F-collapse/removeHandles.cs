removeHandles
	(self submorphs select: [:m | m isMemberOf: Morph])
		do: [:m | m delete]