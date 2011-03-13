services
	^ self serviceCollection reject: [:s | s isCategory]