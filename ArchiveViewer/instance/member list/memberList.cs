memberList
	^ self members collect: [ :ea | self displayLineFor: ea ]