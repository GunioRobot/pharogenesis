processMenuEvent: evt
	| handler localCopyOfEvt |

	localCopyOfEvt := evt clone.
	handler := (HostSystemMenus 
		defaultMenuBarForWindowIndex: (localCopyOfEvt at: 8))
		getHandlerForMenu: (localCopyOfEvt at: 3) item: (localCopyOfEvt at: 4).
	[[handler handler value: localCopyOfEvt] ifError: [:err :rcvr | ]] forkAt: Processor activePriority.