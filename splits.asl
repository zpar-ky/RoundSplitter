
state("BloonsTD6")
{
}

startup
{
    vars.round = 1;
	vars.started = false;
	vars.reset = false;
}

update
{
	string status = File.ReadAllText("round.txt");
	
	if (status == "start" && vars.started == false)
	{
		vars.started = true;
	}
	else if (status == "reset" && vars.reset == false)
	{
		vars.reset = true;
	}
	else
	{
		vars.started = false;
		vars.reset = false;
	}
}

start
{
	return vars.started;
}

reset
{
	return vars.reset;
}

split
{
    string path = "round.txt";
    string text = File.ReadAllText(path);
	int round = 1;
	
	if (text == "win")
	{
		return true;
	}
	
	try
	{
		round = Int32.Parse(text);
	} 
	catch {} // if its not an int it'll error and idc
	
	// MODIFY THIS if you want to have custom splits
	//   e.g. 'round%5' will split every 5 rounds
	//   if you want something more granular that won't be a single line,
	//   just do a bunch of if statements copying below with the else at the end.
	if (round%20 == 0 && vars.round != round)
	{
		vars.round = round;
		return true;
	}
    else
	{
		vars.round = round;
    }
}
