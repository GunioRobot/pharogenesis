trigger
	[self value]
		on: OBAnnouncerRequest
		do: [:notification | notification resume: announcer].