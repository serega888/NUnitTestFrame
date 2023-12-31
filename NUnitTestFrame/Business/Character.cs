﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
	public enum Type
	{
		Human,
		Robot
	}

	public class Character : INotifyPropertyChanged, IDisposable
	{
		private string _name;
		public Type Type { get; }

		public List<string> Weaponry { get; }

		public Character(Type type)
		{
			Type = type;
			Weaponry = new List<string>();
		}

		public Character(Type type, string name) : this(type)
		{
			Name = name;
		}

		public int Armor
		{
			get
			{
				switch (Type)
				{
					case Type.Human:
						return 60;
					case Type.Robot:
						return 100;
				}
				throw new ArgumentOutOfRangeException();
			}
		}

		public bool IsDead => Health <= 0;

		public double Speed
		{
			get
			{
				switch (Type)
				{
					case Type.Human:
						return 1.4;
					case Type.Robot:
						return 1.8;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		public int Wear { get; private set; } = 15;
		public int Health { get; private set; } = 100;

		public int Defense => Wear >= Armor ? 0 : Armor - Wear;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}

		public void Damage(int damage)
		{
			if (damage > 1000)
			{
				throw new ArgumentOutOfRangeException(nameof(damage));
			}
			Health -= damage - Defense;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public override string ToString()
		{
			return Name;
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public void Dispose()
		{
		}
	}
}
