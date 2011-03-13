acceptDroppingMorph: transferMorph event: evt inMorph: listMorph
	^ [(self nodeForDroppedMorph: transferMorph event: evt inMorph: listMorph)
		acceptDroppedNode: transferMorph passenger]
			on: OBAnnouncerRequest
			do: [:notification | notification resume: self announcer]
