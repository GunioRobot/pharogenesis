showResumeButtonInTheWorld

	| w |

	WorldState addDeferredUIMessage: [
		w _ self world.
		w ifNotNil: [
			w addMorphFront:
				(self standaloneResumeButton position: (w right - 100) @ (w top + 10)).
			scorePlayer pause.
			].
	]
