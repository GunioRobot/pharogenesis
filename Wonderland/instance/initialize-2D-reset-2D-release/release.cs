release
	"This method cleans up the Wonderland."

	cameraList do: [:camera | camera release].

	scriptEditor delete.

	"Clean up any uniclasses we created"
	actorClassList do: [:aClass | aClass removeFromSystem ].
