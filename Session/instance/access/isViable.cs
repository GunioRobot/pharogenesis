isViable
	^ (Time now subtractTime: lastAccess) asSeconds > self viableTime