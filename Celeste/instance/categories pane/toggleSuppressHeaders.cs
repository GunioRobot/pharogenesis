toggleSuppressHeaders

	SuppressWorthlessHeaderFields _ SuppressWorthlessHeaderFields not.
	self changed: #messageText.
