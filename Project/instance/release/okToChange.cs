okToChange

	^ (world isMorph not and: [world scheduledControllers size <= 1]) or: [self confirm:
'Are you sure you have saved
all changes that you care about
in ', self name printString].