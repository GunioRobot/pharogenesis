initialize
	Sessions := Dictionary new.
	PWS addToBackupJob: [Session clearOld].

