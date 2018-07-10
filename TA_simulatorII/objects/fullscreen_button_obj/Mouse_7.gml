sprite_index = button_sprite;
textYOffset = 5;

if window_get_fullscreen()
{
	window_set_fullscreen(false);
}
else
{
	window_set_fullscreen(true);
}