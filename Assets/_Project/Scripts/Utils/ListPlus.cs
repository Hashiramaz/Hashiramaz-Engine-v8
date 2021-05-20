using System;
using System.Collections.Generic;

public static class ListPlus
{
	/// <summary>
	/// Gets the last item from list.
	/// </summary>
	/// <returns>The last.</returns>
	/// <param name="myList">My list.</param>
	/// <typeparam name="myType">The 1st type parameter.</typeparam>
	public static myType GetLast<myType> (this List<myType> myList)
	{
		if (myList.Count == 0)
			return default(myType);

		return myList[myList.Count - 1];
	}

	/// <summary>
	/// Removes the last item from list.
	/// </summary>
	/// <param name="myList">My list.</param>
	/// <typeparam name="myType">The 1st type parameter.</typeparam>
	public static void RemoveLast<myType> (this List<myType> myList)
	{
		myList.RemoveAt(myList.Count -1);
	}

	/// <summary>
	/// Picks the random item from list.
	/// </summary>
	/// <returns>The random one.</returns>
	/// <param name="myList">My list.</param>
	/// <typeparam name="myType">The 1st type parameter.</typeparam>
	public static myType PickRandomOne<myType> (this List<myType> myList)
	{
		int randomIndex = 0;
		Random random = new Random();

		randomIndex = random.Next(0, myList.Count);

		if (randomIndex >= myList.Count - 1)
			randomIndex = myList.Count - 1;

		return myList[randomIndex];
	}

	/// <summary>
	/// Picks the random item from array.
	/// </summary>
	/// <returns>The random one.</returns>
	/// <param name="myList">My list.</param>
	/// <typeparam name="myType">The 1st type parameter.</typeparam>
	public static myType PickRandomOne<myType> (this myType[] myList)
	{
		int randomIndex = 0;
		Random random = new Random();
		
		randomIndex = random.Next(0, myList.Length);

		if (randomIndex >= myList.Length - 1)
			randomIndex = myList.Length - 1;
		
		return myList[randomIndex];
	}

	/// <summary>
	/// Picks some randonly.
	/// </summary>
	/// <returns>The some randonly.</returns>
	/// <param name="myList">My list.</param>
	/// <param name="count">Count.</param>
	/// <typeparam name="myType">The 1st type parameter.</typeparam>
	public static List<myType> PickSomeRandonly<myType> (this List<myType> myList, int count)
	{
		List<int> alreadyPicked = new List<int>();
		List<myType> selectedList = new List<myType>();
		Random random = new Random();
		int randomIndex;

		if (count >= myList.Count)
			return myList;

		for (int i = 1; i <= count; i++)
		{
			do
			{
				randomIndex = random.Next(0, myList.Count);

				if (randomIndex >= myList.Count - 1)
					randomIndex = myList.Count - 1;
			}
			while (alreadyPicked.Contains(randomIndex));

			selectedList.Add(myList[randomIndex]);
			alreadyPicked.Add(randomIndex);
		}

		return selectedList;
	}

	/// <summary>
	/// Picks some randonly.
	/// </summary>
	/// <returns>The some randonly.</returns>
	/// <param name="myList">My list.</param>
	/// <param name="count">Count.</param>
	/// <typeparam name="myType">The 1st type parameter.</typeparam>
	public static myType[] PickSomeRandonly<myType> (this myType[] myList, int count)
	{
		List<int> alreadyPicked = new List<int>();
		myType[] selectedList = new myType[Math.Min(count, myList.Length)];
		Random random = new Random();
		int randomIndex;
		
		if (count >= myList.Length)
			return myList;
		
		for (int i = 1; i <= count; i++)
		{
			do
			{
				randomIndex = random.Next(0, myList.Length);
				
				if (randomIndex >= myList.Length - 1)
					randomIndex = myList.Length - 1;
			}
			while (alreadyPicked.Contains(randomIndex));
			
			selectedList[i - 1] = myList[randomIndex];
			alreadyPicked.Add(randomIndex);
		}
		
		return selectedList;
	}

	/// <summary>
	/// Shuffle the specified myList.
	/// </summary>
	/// <param name="myList">List of elements.</param>
	/// <typeparam name="myType">Type of list.</typeparam>
	public static List<myType> Shuffle<myType> (this List<myType> myList)
	{
		myType tempElement;
		int randomIndex = 0;
		Random random = new Random();
		
		for (int count = 0; count < myList.Count; count++)
		{
			do
			{
				randomIndex = random.Next(0, myList.Count - 1);
			}
			while (randomIndex == count);
			
			tempElement = myList[count];
			myList[count] = myList[randomIndex];
			myList[randomIndex] = tempElement;
		}
		
		return myList;
	}

	/// <summary>
	/// Shuffle the specified myList.
	/// </summary>
	/// <param name="myList">List of elements.</param>
	/// <typeparam name="myType">Type of list.</typeparam>
	public static myType[] Shuffle<myType> (this myType[] myList)
	{
		myType tempElement;
		int randomIndex = 0;
		Random random = new Random();
		
		for (int count = 0; count < myList.Length; count++)
		{
			do
			{
				randomIndex = random.Next(0, myList.Length - 1);
			}
			while (randomIndex == count);
			
			tempElement = myList[count];
			myList[count] = myList[randomIndex];
			myList[randomIndex] = tempElement;
		}
		
		return myList;
	}
}