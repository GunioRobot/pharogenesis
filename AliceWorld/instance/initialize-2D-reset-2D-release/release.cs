release
	"This method cleans up the world."

	"Clean up any uniclasses we created"
	actorClassList do: [:aClass | aClass removeFromSystem ].

	"Clean up the output window"
	myTextOutputWindow delete.

	"Get rid of our cameras"
	cameraList do: [:camera | camera release].
