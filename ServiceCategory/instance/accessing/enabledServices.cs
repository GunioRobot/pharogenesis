enabledServices
	^ services
		select: [:e | e isEnabled]