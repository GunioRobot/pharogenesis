endAllNotesAt: endTicks

	activeEvents do: [:evt | evt duration: (endTicks - evt time)].
	activeEvents _ activeEvents species new.
